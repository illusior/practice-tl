import "./App.css";
import ReviewForm from "./Components/Review/Form/ReviewForm";
import ReviewSummary from "./Components/Review/Summary/ReviewSummary";

const MIN_RATE_VALUE: number = 0
const MAX_RATE_VALUE: number = 5

function App(): JSX.Element {
    const reviewStatements: Array<string> = [
        "Cleanliness",
        "Customer Service",
        "Speed",
        "Location",
        "Facilities",
    ];

    return (
        <div className="container reviewer">
            <div className="container review-form">
                <ReviewForm mainTitle="How nice was my reply?"
                            reviewStatementTitles={reviewStatements}
                            minStatementValue={MIN_RATE_VALUE}
                            maxStatementValue={MAX_RATE_VALUE}/>
            </div>
            <div className="container review-summary">
                <ReviewSummary />
            </div>
        </div>
    )
}

export default App
