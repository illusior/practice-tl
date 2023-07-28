class ValueRange<T> {
    readonly min: T;
    readonly max: T;

    constructor(min: T, max: T) {
        if (min > max)
        {
            [min, max] = [max, min]
        }

        this.min = min
        this.max = max
    }

    inRange(value: T): boolean {
        return this.min <= value && value >= this.max
    }
}

export default ValueRange
