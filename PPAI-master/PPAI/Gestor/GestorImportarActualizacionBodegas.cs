using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Entidades;

namespace PPAI.Gestor
{
    public class GestorImportarActualizacionBodegas
    {
        public List<Bodega>? bodegasParaActualizar {  get; set; }
        public Bodega? bodegaSeleccionada { get; set; }
        public List<Vino>? DatosDeVinosDeBodegaParaActualizar { get; set; }
        public List<Maridaje>? MaridajeParaVinosACrear { get; set; }
        public List<TipoUva>? TipoUvaParaVinosACrear { get; set; }
        public List<Usuario>? NombresUsuariosSeguidoresDeBodega { get; set; }

        public static void OpcionImportarActualizacionVinosBodega()
        {

        }
        public void BuscarBodegaParaActualizar()
        {
            
        }
    }
}
