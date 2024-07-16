
namespace Webbing.Assignment.Service.Repository.Abstract
{
	public interface IBaseRepository
	{
		Task<int> SaveChanges();
	}
}