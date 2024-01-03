using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro
{
    internal class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabuleiro(int linha, int colunas)
        {
            this.linhas = linha;
            this.colunas = colunas;
            pecas = new Peca[linha,colunas];
        }

        public Peca peca (int linha,int coluna)
        {
            return pecas[linha,coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public void colocarpeca(Peca p, Posicao pos)
        {
            pecas[pos.linha, pos.coluna] = p;
            p.posicao = pos;
        }

        public bool posicaoValida(Posicao pos)
        {
            if (pos.linha<0 || pos.linha>=linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {

        }
    }
}
