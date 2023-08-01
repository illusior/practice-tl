import "./App.css";
import { CreateReviewSummaries } from "./Components/Review/Summary/ReviewSummary";
import { useCallback, useState } from "react";
import ReviewForm from "./Components/Review/Form/ReviewForm";
import ReviewOptionT, { CreateReviewOptions } from "./Components/Review/Types/ReviewOptionT";
import ReviewSummaryT from "./Components/Review/Types/ReviewSummaryT";

const REVIEW_STATEMENTS_TITLES: string[] = ["Cleanliness", "Customer Service", "Speed", "Location", "Facilities"];

const MIN_RATE_VALUE: number = 0;
const MAX_RATE_VALUE: number = 5;

const REVIEW_OPTION_INFOS: ReviewOptionT[] = CreateReviewOptions(
    REVIEW_STATEMENTS_TITLES,
    MIN_RATE_VALUE,
    MAX_RATE_VALUE,
);

function App(): JSX.Element {
    const [reviewSummaries, setReviewSummaries] = useState<ReviewSummaryT[]>([]);

    const onReviewSubmit = useCallback((newReview: ReviewSummaryT) => {
        setReviewSummaries(prevReviews => [...prevReviews, newReview]);
    }, []);

    return (
        <div className="reviewer">
            <div className="review-form">
                <ReviewForm
                    mainTitle="How nice was my reply?"
                    reviewOptionInfos={REVIEW_OPTION_INFOS}
                    onReviewSubmit={onReviewSubmit}
                />
            </div>

            {reviewSummaries.length > 0 && <hr className="review-form-hr-reviews" />}

            <div className="review-summaries">{CreateReviewSummaries(reviewSummaries)}</div>
        </div>
    );
}

export default App;
