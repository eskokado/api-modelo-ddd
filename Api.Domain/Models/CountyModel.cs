using System;

namespace Api.Domain.Models
{
    public class CountyModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        private int _codeIBGE;
        public int CodeIBGE
        {
            get { return _codeIBGE; }
            set { _codeIBGE = value; }
        }
        
        private Guid _ufId;
        public Guid UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }
        
    }
}