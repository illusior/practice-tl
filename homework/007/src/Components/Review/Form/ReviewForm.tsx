import "./ReviewForm.css";
import { CreateReviewOptionInputs } from "../Option/ReviewOption";
import { RandomNicknameGenerator, DATA_SETS } from 'random-nickname-generator';
import { useRef, useState } from "react";
import Grade from "../../Text/Grade";
import ReviewOptionT, { ReviewOptionRateValueT } from "../Types/ReviewOptionT";
import ReviewSummaryT from "../Types/ReviewSummaryT";

type OnReviewFormSubmitCallbackT = (reviewSummary: ReviewSummaryT) => void;

interface ReviewFormProps {
    mainTitle: string;
    reviewOptionInfos: ReviewOptionT[];

    onReviewSubmit: OnReviewFormSubmitCallbackT;
}

const randomNicknameGenConfig = {
    structure: [
        DATA_SETS.ANIMALS,
        DATA_SETS.ADJECTIVES,
      ],
      separator: ' ',
}

function ReviewForm({ mainTitle, reviewOptionInfos, onReviewSubmit }: ReviewFormProps): JSX.Element {
    const reviewTextRef = useRef<HTMLTextAreaElement>(null);
    const [rateStatesSum, setRateStatesSum] = useState<ReviewOptionRateValueT>(0.0);

    const reviewOptionCount: number = reviewOptionInfos.length;

    const onSubmitCallback = (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
        e.preventDefault();

        const reviewHasText = reviewTextRef.current !== undefined;
        const reviewTextInput: string = reviewTextRef.current?.value ?? "";
        reviewHasText && (reviewTextRef.current!.value = "");

        const nickname: string = RandomNicknameGenerator.generate(randomNicknameGenConfig);

        onReviewSubmit(new ReviewSummaryT(nickname, reviewTextInput, rateStatesSum, reviewOptionCount));
    };

    return (
        <form className="review-form-container">
            <div className="review-form-content">
                <div className="review-form-title-content">
                    <h2 className="review-form-title">{mainTitle}</h2>
                </div>
                <div className="review-form-edit">
                    <div className="review-form-options">
                        {CreateReviewOptionInputs(reviewOptionInfos, setRateStatesSum)}
                    </div>

                    <textarea className="review-form-text-input" placeholder="What could we improve?" ref={reviewTextRef} />

                    <button className="review-form-submit-button" type="submit" onClick={onSubmitCallback}>
                        Send
                    </button>
                </div>
            </div>

            <Grade className="review-total-grade" gradeSum={rateStatesSum} total={reviewOptionCount} />
        </form>
    );
}

export default ReviewForm;
