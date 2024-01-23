using System;
using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez
{
    internal class Rei : Peca 
    {

        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab,Cor cor,PartidaDeXadrez partida) : base(cor, tab) 
        { 
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        public bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qteMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha,pos.coluna] = true;
            }

            //ne
            pos.definirValores(posicao.linha - 1, posicao.coluna+1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //se
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //so
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }

            //no
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tab.posicaoValida(pos) && podeMover(pos))
            {
                mat[pos.linha, pos.coluna] = true;
            }
            //#Jogada Especial roque
            if(qteMovimentos==0 && !partida.Xeque)
            {
                //#Jogada Especial roque pequeno
                Posicao PosT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(PosT1))
                {
                    Posicao P1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao P2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if(tab.peca(P1) == null && tab.peca(P2) == null)
                    {
                        mat[posicao.linha,posicao.coluna +2] = true;
                    }
                }
                //#Jogada Especial roque Grande
                Posicao PosT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(PosT2))
                {
                    Posicao P1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao P2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao P3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tab.peca(P1) == null && tab.peca(P2) == null && tab.peca(P3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}   
