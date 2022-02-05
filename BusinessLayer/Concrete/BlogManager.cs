using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }


        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetBlogListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetBlogListWithCategoryByWriter(id);
        }
        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }
        public List<Blog>GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x=>x.WriterId==id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetListAll(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
