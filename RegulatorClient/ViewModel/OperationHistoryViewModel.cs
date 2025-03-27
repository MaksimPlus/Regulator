namespace RegulatorClient.ViewModel;
public class OperationHistoryViewModel
{
    public IReadOnlyList<OperationLog>? Operations { get; }
    public OperationHistoryViewModel(IReadOnlyList<OperationLog>? operations)
    {
        Operations = operations;
    }
}
