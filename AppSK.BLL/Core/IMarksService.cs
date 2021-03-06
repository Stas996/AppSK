﻿using AppSK.DAL.Entities;
using System.Linq;

namespace AppSK.BLL.Core
{
    public interface IMarksService
    {
        IQueryable<Mark> GetMarks();

        Mark GetMarkByProject(int projectId);

        Mark GetMarkByStock(int stockId);

        Mark GetMark(int id);

        int Save(Mark mark);

        void Delete(int id);
    }
}
