using System;

namespace Contracts;

public interface IRepositoryManager
{
    void Save();
    IRepositoryCourse Course { get; }
    IRepositoryEntrollment Entrollment { get; }
    IRepositoryStudent Student { get; }
}
