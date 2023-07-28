import {
    OptPropertyRateValueT,
    PropertyRateValueT,
    ReviewPropertyType,
} from "../Types/ReviewProperty"
import "./ReviewProperty.css"

type OnPropertyRateChangeCallbackT = (propertyTitle: string, newReviewRate: PropertyRateValueT) => void

// export const OnPropertyRateChangeCallback: OnPropertyRateChangeCallbackT =
//     (propertyTitle: string, newReviewRate: PropertyRateValueT) => {


// }

interface ReviewPropertyProps {
    reviewPropertyState: ReviewPropertyType
    onPropertyRateChange: OnPropertyRateChangeCallbackT
}

export function ReviewProperty({ reviewPropertyState, onPropertyRateChange }: ReviewPropertyProps): JSX.Element {
    const pTitle: string = reviewPropertyState.title
    const pRateRange: ReviewPropertyType['rateRange'] = reviewPropertyState.rateRange
    const pMinValue: PropertyRateValueT = pRateRange.min
    const pMaxValue: PropertyRateValueT = pRateRange.max
    const pValue: OptPropertyRateValueT = pRateRange.value

    return (
        <div className="container review-property">
            <input className="review-property__input"
                   type="range"
                   id={pTitle}
                   name={pTitle}
                   min={pMinValue}
                   max={pMaxValue}
                   value={pValue}
                   onChange={e => {
                    const newRate: PropertyRateValueT = Number((e.target as HTMLInputElement).value)
                    onPropertyRateChange(pTitle, newRate)
                   }} />
            <label className="review-property__label" htmlFor={pTitle}>
                {pTitle}
            </label>
        </div>
    )
}

export default ReviewProperty
