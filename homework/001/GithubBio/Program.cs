// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Net.Http.Json;

const string HTTP_GITHUB_USER_BASE_ADDRES = "https://api.github.com/users/";
Uri MakeGithubUserInfoApiUri(string githubUsername)
{
    return new Uri($"{HTTP_GITHUB_USER_BASE_ADDRES}{githubUsername}");
}

var httpClient = new HttpClient();

httpClient.DefaultRequestHeaders.Add("accept", "application/vnd.github+json");
httpClient.DefaultRequestHeaders.Add("User-Agent", "consoleApp");

var httpRequest = new HttpRequestMessage
{
    Method = HttpMethod.Get,
};

string githubUsername = "";

Console.WriteLine("This program outputs user github profile's public info by given username");
Console.WriteLine();

HttpResponseMessage response = new();
bool isStatusOk = false;
do
{
    Console.Write("Github profile username: ");
    githubUsername = Console.ReadLine() ?? "";
    httpClient.BaseAddress = MakeGithubUserInfoApiUri(githubUsername);
    try
    {
        response = httpClient.Send(httpRequest);
    }
    catch (Exception)
    {
        Console.WriteLine($"Something went wrong while sending HTTP request to {HTTP_GITHUB_USER_BASE_ADDRES}");
        break;
    }

    isStatusOk = response.StatusCode == System.Net.HttpStatusCode.OK;
    if (!isStatusOk)
    {
        Console.WriteLine("No such user");
        break;
    }

    Console.WriteLine();

    var responseJson = await response.Content.ReadFromJsonAsync(typeof(GithubUser)) as GithubUser;
    Console.WriteLine($@"
    #------------------------------------------------------------#
    User info:
        --[  name            ]-- {responseJson.name ?? "Unknown"} \
        --[  email           ]-- {responseJson.email ?? "Unknown"} \
        --[  bio             ]-- {responseJson.bio ?? "Unknown"} \

        --[  company         ]-- {responseJson.company ?? "Unknown"} \
        --[  followers_count ]-- {responseJson.followers ?? 0} \
        --[  following_count ]-- {responseJson.following ?? 0} \
        --[  gists_count     ]-- {responseJson.public_gists ?? 0} \
        --[  location        ]-- {responseJson.location ?? "Unknown"} \
        --[  login           ]-- {responseJson.login ?? "Unknown"} \
        --[  repos_count     ]-- {responseJson.public_repos ?? 0} \
        --[  twitter         ]-- {responseJson.twitter_username ?? "Unknown"} \
    #------------------------------------------------------------#
    ");
} while (!isStatusOk);

record GithubUser(
    string? login,
    int? id,
    string? node_id,
    string? avatar_url,
    string? gravatar_id,
    string? url,
    string? html_url,
    string? followers_url,
    string? following_url,
    string? gists_url,
    string? starred_url,
    string? subscriptions_url,
    string? organizations_url,
    string? repos_url,
    string? events_url,
    string? received_events_url,
    string? type,
    bool? site_admin,
    string? name,
    string? company,
    string? blog,
    string? location,
    string? email,
    string? hireable,
    string? bio,
    string? twitter_username,
    int? public_repos,
    int? public_gists,
    int? followers,
    int? following,
    string? created_at,
    string? updated_at
);
