using ProjectManagement.Domain.Entities;

namespace Softwash.Infrastructure.UnitOfWorks;
    public interface IUnitOfWork
    {
        

        #region Auth
        IRepository<Login> LoginRepo { get; }
        IRepository<User> UserRepo { get; }

    #endregion

    #region Project
    IRepository<Project> ProjectRepo { get; }
    IRepository<ProjectTask> ProjectTaskRepo { get; }
    #endregion

    




    Task<int> Save();
    Task<int> Delete();

}

