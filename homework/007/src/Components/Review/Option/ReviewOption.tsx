import { FormEvent, useState } from "react";
import ReviewOptionT, { OptReviewOptionRateValueT, ReviewOptionRateValueT } from "../Types/ReviewOptionT";
import "./ReviewOption.css";

export type OnOptionRateInputCallbackT = (
    propertyTitle: string,
    oldReviewRate: OptReviewOptionRateValueT,
    newReviewRate: ReviewOptionRateValueT,
) => void;

interface ReviewPropertyProps {
    reviewPropertyInfo: ReviewOptionT;
    onOptionRateInput: OnOptionRateInputCallbackT;
}

export function ReviewOption({ reviewPropertyInfo, onOptionRateInput }: ReviewPropertyProps): JSX.Element {
    const rpTitle: string = reviewPropertyInfo.title;
    const rpRateRange: ReviewOptionT["rateRange"] = reviewPropertyInfo.rateRange;
    const [rpMinValue, rpMaxValue] = [rpRateRange.min, rpRateRange.max];

    const [rateValue, setRateValue] = useState<OptReviewOptionRateValueT>(undefined);
    const onRateInput = (e: FormEvent) => {
        const newRate: ReviewOptionRateValueT = Number((e.target as HTMLInputElement).value);
        setRateValue(newRate);
        onOptionRateInput(rpTitle, rateValue, newRate);
    };

    return (
        <div className="container review-property">
            <input
                className="review-property-input"
                id={rpTitle}
                max={rpMaxValue}
                min={rpMinValue}
                name={rpTitle}
                onInput={onRateInput}
                type="range"
                value={rateValue ?? 0}
            />
            <label className="review-property_label" htmlFor={rpTitle}>
                {rpTitle}
            </label>
        </div>
    );
}

export const CreateReviewOptionInputs = (
    reviewOptions: ReviewOptionT[],
    optionRatesSum: ReviewOptionRateValueT,
    setOptionRateStates: React.Dispatch<React.SetStateAction<ReviewOptionRateValueT>>,
): JSX.Element[] => {
    return reviewOptions.map((rOption: ReviewOptionT) => {
        return (
            <ReviewOption
                key={`${rOption.title}`}
                reviewPropertyInfo={rOption}
                onOptionRateInput={(
                    changedOptionTitle: string,
                    oldReviewRate: OptReviewOptionRateValueT,
                    newOptionRate: ReviewOptionRateValueT,
                ) => {
                    if (changedOptionTitle === rOption.title) {
                        setOptionRateStates(optionRatesSum - (oldReviewRate ?? 0) + newOptionRate);
                    }
                }}
            />
        );
    });
};

export default ReviewOption;
