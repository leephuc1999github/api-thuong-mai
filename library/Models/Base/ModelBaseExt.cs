using library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace library.Models.Base
{
    public abstract class ModelBaseExt
    {
        [Key]
        private int _ID;

        private DateTime? _Created;
        private string _CreatedBy;
        private DateTime? _Modified;
        private string _ModifiedBy;
        public ModelBaseExt()
        {
            
        }


        public int ID { get { return this._ID; } set { this._ID = value; } }

        public DateTime? Created { get { return this._Created; } set { this._Created = value; } }
        public string CreatedBy { get { return this._CreatedBy; } set { this._CreatedBy = value; } }
        public DateTime? Modified { get { return this._Modified; } set { this._Modified = value; } }
        public string ModifiedBy { get { return this._ModifiedBy; } set { this._ModifiedBy = value; } }
    }
}
