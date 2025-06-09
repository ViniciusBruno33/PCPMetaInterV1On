using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using PCPMetalurgicaInter.Dados;
using PCPMetalurgicaInter.Models;

namespace PCPMetalurgicaInter.Services
{
    public class PecaService
    {
        public required RepPeca _repository;
        public PecaService(RepPeca repository)
        {
            _repository = repository;
        }
        public List<Peca> GetAll()
        {
            return _repository.GetAll();
        }
        public Peca GetById(int? id)
        {
            if (id != null)
            {
            return _repository.GetById(id.Value);  
            }
            throw new ArgumentException("Erro: Nenhum id inserido");
        }
        public List<Subproduto> GetSubprodutos(int? id)
        {
            if (id != null)
            {
                Peca peca = _repository.GetById(id.Value);
                return _repository.GetSubprodutos(peca);
            }
            throw new ArgumentException("");
        }
        public string Imprimir(Peca x)
        {
            if (x == null)
            {
                throw new ArgumentNullException("Erro: nenhuma peça inserida na requisição");
            }
            if (x.Imagem == null)
            {
                throw new ArgumentException("Erro: A peça não possui imagem cadastrada");
            }
            var y = _repository.Imprimir(x);
            return y;
        }
        public bool Insert(Peca x)
        {
            bool resp = false;
            if (x != null)
            {
                _repository.Insert(x);
                _repository.Save();
                resp = true;
            }
            return resp;
        }
        public bool Update(Peca x) 
        {
            bool resp = false;
            if (x != null)
            {
                _repository.Update(x);
                _repository.Save();
                resp = true;
            }
            return resp;
        }
        public bool Delete(int? id)
        {
            bool resp = false;
            if (id != null)
            {
                _repository.Delete(id.Value);
                _repository.Save();
                resp = true;
            }
            return resp;
        }
    }
}