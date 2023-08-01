import "./ReviewSummary.css";
import Grade from "../../Text/Grade";
import ReviewSummaryT from "../Types/ReviewSummaryT";

interface ReviewSummaryProps {
    reviewSummary: ReviewSummaryT;
}

function ReviewSummary({ reviewSummary }: ReviewSummaryProps): JSX.Element {
    return (
        <>
            <img className="user-image" alt="user image" crossOrigin="" src="/assets/face_placeholder.png" />
            <div className="review-text">
                <h3 className="review-text-title">{reviewSummary.title}</h3>
                <h4 className="review-text-content">{reviewSummary.textBody}</h4>
            </div>
            <Grade className="review-grade" gradeSum={reviewSummary.totalRate} total={reviewSummary.maxSumRate} />
        </>
    );
}

export function CreateReviewSummaries(reviewSummaries: ReviewSummaryT[]): JSX.Element[] {
    return reviewSummaries.map((reviewSummary: ReviewSummaryT, index: number) => (
        <div className="review-summary-container" key={index}>
            {ReviewSummary({
                reviewSummary,
            })}
        </div>
    ));
}

export default ReviewSummary;
