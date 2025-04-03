using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroHQAppAndroid.Data
{
    public class HQ
    {
        [PrimaryKey, AutoIncrement]
        public virtual Guid HQId { get; set; }

        public string Editora { get; set; }

        public string Titulo { get; set; }

        public int NumeroEdicao { get; set; }

        public int Categoria { get; set; }

        public int Genero { get; set; }

        public int Status { get; set; }

        public int Formato { get; set; }

        public string LinkDetalhes { get; set; }

        public string ThumbCapa { get; set; }

        public string Licenciador { get; set; }

        public int NumeroPaginas { get; set; }

        public string Preco { get; set; }

        public string DataPublicacao { get; set; }

        public string Capa { get; set; }

        public string Personagens { get; set; }

        public string DesenhosRoteirosArteFinalCores { get; set; }

        public int Lido { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }

    }
}
