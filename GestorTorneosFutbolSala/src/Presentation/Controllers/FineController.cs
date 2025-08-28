using GestorTorneosFutbolSala.Domain.Entities;
using GestorTorneosFutbolSala.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorTorneosFutbolSala.src.Presentation.Controllers
{
    /// <summary>
    /// Controller responsible for handling CRUD operations and data access for fines (multas) in the system.
    /// </summary>
    /// 

    public class FineController
    {
        private readonly FineService _service;

        public FineController()
        {
            _service = new FineService();
        }

        public List<Fine> GetAllFines()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las multas.", ex);
            }
        }

        public int GetFineById(int id)
        {
            try
            {
                return _service.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar la multa con ID {id}.", ex);
            }
        }

        public void CreateFine(Fine fine)
        {
            try
            {
                _service.Create(fine);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la multa.", ex);
            }
        }

        public void UpdateFine(Fine fine)
        {
            try
            {
                _service.Update(fine);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la multa.", ex);
            }
        }

        public void DeleteFine(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la multa.", ex);
            }
        }
    }
}
