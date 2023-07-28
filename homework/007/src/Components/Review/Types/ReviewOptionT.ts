import ValueRangeT from "../../../Types/ValueRangeT";

export type ReviewOptionRateValueT = number;
export type OptReviewOptionRateValueT = ReviewOptionRateValueT | undefined;

export class ReviewOptionRate extends ValueRangeT<ReviewOptionRateValueT> {}

export default interface ReviewOptionT {
    readonly title: string;
    rateRange: ReviewOptionRate;
}

export function CreateReviewOptions(
    optionTitles: string[],
    minRateValue: ReviewOptionRateValueT,
    maxRateValue: ReviewOptionRateValueT,
): ReviewOptionT[] {
    return optionTitles.map((title: string) => {
        return {
            title: title,
            rateRange: new ReviewOptionRate(minRateValue, maxRateValue),
        };
    });
}
