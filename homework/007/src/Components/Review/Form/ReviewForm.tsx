import { useState } from "react";
import { ReviewProperty } from "../Property/ReviewProperty"
import {
    ReviewPropertyType,
    PropertyRateType,
    PropertyRateValueT,
    OptPropertyRateValueT
} from "../Types/ReviewProperty"
import "./ReviewForm.css"

interface ReviewFormProps {
    mainTitle: string;
    reviewStatementTitles: Array<string>;
    minStatementValue: PropertyRateValueT;
    maxStatementValue: PropertyRateValueT;
}

function ReviewForm({ mainTitle,
    reviewStatementTitles,
    minStatementValue,
    maxStatementValue }: ReviewFormProps): JSX.Element {

    // eslint-disable-next-line @typescript-eslint/no-unused-vars
    const [rateStates, setRateStates] = useState(reviewStatementTitles.map<OptPropertyRateValueT>(_ => undefined))

    const reviewStatements: Array<ReviewPropertyType> = reviewStatementTitles
        .map((title: string, index: number) => {
            const propertyRateMin: PropertyRateValueT = minStatementValue
            const propertyRateMax: PropertyRateValueT = maxStatementValue
            const rateValue: OptPropertyRateValueT = rateStates[index]

            return {
                title: title,
                rateRange: new PropertyRateType(
                    propertyRateMin,
                    propertyRateMax,
                    rateValue,
                )
            }
    })

    const reviewPropertiesSum: OptPropertyRateValueT = rateStates
        .reduce((accumulate: OptPropertyRateValueT, currValue: OptPropertyRateValueT) => {
        return (accumulate && currValue) ? accumulate + currValue : accumulate
    })

    const reviewPropertiesCount: number = reviewStatements.length
    const averageSum: number = (reviewPropertiesSum ?? 0) / reviewPropertiesCount

    return (
        <>
            <form className="container review-form">
                <h1 className="review-form__title">
                    {mainTitle}
                </h1>

                {reviewStatements.map((rPropState: ReviewPropertyType) => {
                    return <ReviewProperty key={rPropState.title}
                        reviewPropertyState={rPropState}
                        onPropertyRateChange={(pTitle: string, newRate: PropertyRateValueT) => {
                            setRateStates(reviewStatements
                                .map<OptPropertyRateValueT>((reviewProperty: ReviewPropertyType) => {
                                    return (pTitle === reviewProperty.title)
                                        ? newRate
                                        : reviewProperty.rateRange.value
                            }))
                    }} />
                })}

                <h1>{averageSum}/{reviewPropertiesCount}</h1>

                <textarea className="review-form__text-input"
                          placeholder="What could we improve?">
                </textarea>

                <button className="review-form__submit-button"
                        type="button">Send</button>
            </form>
        </>
    )
}

export default ReviewForm
