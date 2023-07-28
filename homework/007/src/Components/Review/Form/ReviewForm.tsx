import { useState } from "react";
import { CreateReviewOptionInputs } from "../Option/ReviewOption";
import ReviewOptionT, { CreateReviewOptions, ReviewOptionRateValueT } from "../Types/ReviewOptionT";
import "./ReviewForm.css";
import Grade from "../../Text/Grade";

interface ReviewFormProps {
    mainTitle: string;
    reviewOptionTitles: string[];
    minROptionValue: ReviewOptionRateValueT;
    maxROptionValue: ReviewOptionRateValueT;
}

function ReviewForm({ mainTitle, reviewOptionTitles, minROptionValue, maxROptionValue }: ReviewFormProps): JSX.Element {
    const [rateStatesSum, setRateStatesSum] = useState<ReviewOptionRateValueT>(0.0);

    const reviewOptionInfos: ReviewOptionT[] = CreateReviewOptions(
        reviewOptionTitles,
        minROptionValue,
        maxROptionValue,
    );

    const reviewPropertiesCount: number = reviewOptionInfos.length;

    return (
        <>
            <form className="container review-form">
                <h1 className="review-form-title">{mainTitle}</h1>

                {CreateReviewOptionInputs(reviewOptionInfos, rateStatesSum, setRateStatesSum)}

                <Grade average={(rateStatesSum ?? 0) / reviewPropertiesCount} total={reviewPropertiesCount} />

                <textarea className="review-form-text-input" placeholder="What could we improve?"></textarea>

                <button className="review-form-submit-button" type="button">
                    Send
                </button>
            </form>
        </>
    );
}

export default ReviewForm;
