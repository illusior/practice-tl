interface GradeProps {
    className: string;
    gradeSum: number;
    total: number;
}

function Grade({ className, gradeSum, total }: GradeProps): JSX.Element {
    return (
        <div className={className}>
            {gradeSum / total}/{total}
        </div>
    );
}

export default Grade;
