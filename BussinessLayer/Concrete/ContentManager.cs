﻿using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _ContentDal;

        public ContentManager(IContentDal contentDal)
        {
            _ContentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _ContentDal.Insert(content);
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentyDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentyUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string p)
        {
            if (string.IsNullOrEmpty(p))
            {
                return _ContentDal.List();
            }
            return _ContentDal.List(x => x.ContentValue.Contains(p));
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _ContentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _ContentDal.List(x => x.WriterId == id);
        }
    }
}
