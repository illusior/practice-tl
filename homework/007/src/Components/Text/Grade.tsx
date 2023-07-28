type GradeProps = {
    average: number;
    total: number;
};

function Grade({ average, total }: GradeProps): JSX.Element {
    return (
        <div className="grade">
            {average}/{total}
        </div>
    );
}

export default Grade;
