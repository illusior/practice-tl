import "./ReviewOption.css";
import { FormEvent, memo, useCallback, useState } from "react";
import ReviewOptionT, { OptReviewOptionRateValueT, ReviewOptionRateValueT } from "../Types/ReviewOptionT";

export type OnOptionRateInputCallbackT = (
    oldReviewRate: OptReviewOptionRateValueT,
    newReviewRate: ReviewOptionRateValueT,
) => void;

interface ReviewOptionProps {
    reviewOptionInfo: ReviewOptionT;
    onOptionRateInput: OnOptionRateInputCallbackT;
}

export function ReviewOption({ reviewOptionInfo, onOptionRateInput }: ReviewOptionProps): JSX.Element {
    const rpTitle: string = reviewOptionInfo.title;
    const rpRateRange: ReviewOptionT["rateRange"] = reviewOptionInfo.rateRange;
    const [rpMinValue, rpMaxValue] = [rpRateRange.min, rpRateRange.max];

    const [rateValue, setRateValue] = useState<OptReviewOptionRateValueT>(undefined);
    const onRateInput = useCallback(
        (e: FormEvent) => {
            const newRate: ReviewOptionRateValueT = Number((e.target as HTMLInputElement).value);
            onOptionRateInput(rateValue, newRate);
            setRateValue(newRate);
        },
        [rateValue],
    );

    const filteredId: string = rpTitle.toLowerCase().replace(" ", "-");

    return (
        <div className="review-option">
            <input
                className="review-option-input"
                id={filteredId}
                list={`${filteredId}-list`}
                max={rpMaxValue}
                min={rpMinValue}
                name={filteredId}
                onInput={onRateInput}
                type="range"
                value={rateValue ?? 0}
            />
            <label className="review-option-label" htmlFor={filteredId}>
                {rpTitle}
            </label>
        </div>
    );
}

export const MemoReviewOption = memo(ReviewOption);

export const CreateMemoReviewOptionInputs = (
    reviewOptions: ReviewOptionT[],
    setOptionRateStates: React.Dispatch<React.SetStateAction<ReviewOptionRateValueT>>,
): JSX.Element[] => {
    const onOptionRateInputCallback = useCallback(
        (oldReviewRate: OptReviewOptionRateValueT, newOptionRate: ReviewOptionRateValueT) => {
            setOptionRateStates(prevRatesSum => prevRatesSum - (oldReviewRate ?? 0) + newOptionRate);
        },
        [setOptionRateStates],
    );

    return reviewOptions.map((rOption: ReviewOptionT) => {
        return (
            <MemoReviewOption
                key={`${rOption.title}`}
                reviewOptionInfo={rOption}
                onOptionRateInput={onOptionRateInputCallback}
            />
        );
    });
};

export default ReviewOption;
