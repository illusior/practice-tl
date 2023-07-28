import ValueRange from "../../../Types/ValueRange";

export type PropertyRateValueT = number
export type OptPropertyRateValueT = PropertyRateValueT | undefined

export class PropertyRateType extends ValueRange<PropertyRateValueT> {
    _value: OptPropertyRateValueT

    constructor(min: PropertyRateValueT,
        max: PropertyRateValueT,
        currValue: PropertyRateValueT = 0) {

        super(min, max);
        this._value = currValue

        if (this.hasValue() && !this.inRange(currValue))
        {
            this._value = 0
        }
    }

    public hasValue(): boolean {
        return this._value !== undefined
    }

    public get value(): OptPropertyRateValueT {
        return this._value
    }

    public set value(newRate: PropertyRateValueT) {
        this._value = newRate
    }
}

export interface ReviewPropertyType {
    readonly title: string;
    rateRange: PropertyRateType;
}
