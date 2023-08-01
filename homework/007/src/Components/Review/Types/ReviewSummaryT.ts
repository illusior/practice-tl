import { ReviewOptionRateValueT } from "./ReviewOptionT";

class ReviewSummaryT {
    public readonly maxSumRate: ReviewOptionRateValueT;
    public readonly totalRate: ReviewOptionRateValueT;
    public readonly textBody: string;
    public readonly title: string;

    public constructor(
        title: string,
        textBody: string,
        sumRate: ReviewOptionRateValueT,
        maxRate: ReviewOptionRateValueT,
    ) {
        this.totalRate = sumRate;
        this.maxSumRate = maxRate;

        this.title = title;
        this.textBody = textBody;
    }
}

export default ReviewSummaryT;
