namespace Study.Lab2.Logic.Interfaces.UTBL;

public interface IRequestService : IDisposable
{
    /// <summary>
    /// ��������� ������ � �������
    /// </summary>
    /// <param name="url">���-�����</param>
    /// <returns>����� �� �������</returns>
    string FetchData(string url);

    /// <summary>
    /// ��������� ������ � �������
    /// </summary>
    /// <param name="url">���-�����</param>
    /// <param name="cancellationToken">����� ������</param>
    /// <returns>����� �� �������</returns>
    Task<string> FetchDataAsync(string url, CancellationToken cancellationToken = default);
}