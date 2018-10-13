using App2.Layers.Business;
using App2.Model;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace App2.ViewModel
{
    class DetalhesTimeViewModel : INotifyPropertyChanged
    {
        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private DetalhesTimeModel detalhesTime;

        public DetalhesTimeModel DetalhesTime
        {
            get { return detalhesTime; }
            set { if (detalhesTime != value) detalhesTime = value; NotifyPropertyChanged(); }
        }

        public DetalhesTimeViewModel()
        {
            DetalhesTime = new DetalhesTimeModel();

            DetalhesTime = new TimeBusiness().GetDetalheTime();

            Grafico = GerarGraficoPizza(DetalhesTime);
        }


        private PlotModel GerarGraficoPizza(DetalhesTimeModel detalhes)
        {



            var valores = new PieSeries
            {
                Stroke = OxyColors.White,
                StrokeThickness = 1.0,
                Diameter = 1.0,
                InnerDiameter = 0.0,
                StartAngle = 90.0,
                AngleSpan = 360.0,
                AngleIncrement = 1.0,
                OutsideLabelFormat = "{1}",
                InsideLabelFormat = "{0}",
                TickDistance = 0.5,
                TickRadialLength = 6,
                TickHorizontalLength = 1,
                TickLabelDistance = 1,
                InsideLabelPosition = 0.5,
                FontSize = 12,
            };

            #region validando Valores para o Grafico
            if (detalhes.Cartao_amarelo > 0)
                valores.Slices.Add(
                                  new PieSlice("Cartões amarelos", detalhes.Cartao_amarelo)
                              );
            if (detalhes.Cartao_vermelho > 0)
                valores.Slices.Add(
                                  new PieSlice("Cartões vermelhos", detalhes.Cartao_vermelho)
                              );

            if (detalhes.Chute_para_fora > 0)
                valores.Slices.Add(
                                  new PieSlice("Chutes para fora", detalhes.Chute_para_fora)
                              );
            if (detalhes.Chute_para_gol > 0)
                valores.Slices.Add(
                                  new PieSlice("Chutes para o gol", detalhes.Chute_para_gol)
                              );
            if (detalhes.Cruzamento > 0)
                valores.Slices.Add(
                                  new PieSlice("Cruzamentos", detalhes.Cruzamento)
                              );
            if (detalhes.Defesa > 0)
                valores.Slices.Add(
                                  new PieSlice("Defesas", detalhes.Defesa)
                              );
            if (detalhes.Drible > 0)
                valores.Slices.Add(
                                  new PieSlice("Drible", detalhes.Drible)
                              );
            if (detalhes.Falta_cometida > 0)
                valores.Slices.Add(
                                  new PieSlice("Faltas cometidas", detalhes.Falta_cometida)
                              );
            if (detalhes.Falta_tomada > 0)
                valores.Slices.Add(
                                  new PieSlice("Faltas tomadas", detalhes.Falta_tomada)
                              );
            if (detalhes.Gol > 0)
                valores.Slices.Add(
                                  new PieSlice("Gols feitos", detalhes.Gol)
                              );
            if (detalhes.Gol_tomado > 0)
                valores.Slices.Add(
                                   new PieSlice("Gols tomados", detalhes.Gol_tomado)
                              );
            if (detalhes.Passe_certo > 0)
                valores.Slices.Add(
                                  new PieSlice("Passes certos", detalhes.Passe_certo)
                              );
            if (detalhes.Passe_errado > 0)
                valores.Slices.Add(
                                  new PieSlice("Passes errados", detalhes.Passe_errado)
                              );
            if (detalhes.Tomada_de_bola > 0)
                valores.Slices.Add(
                                  new PieSlice("Tomadas de bola", detalhes.Tomada_de_bola)
                              );

            #endregion

            var plotModel = new PlotModel
            {
                IsLegendVisible = true
            };
            plotModel.Series.Add(valores);


            return plotModel;
        }

        private OxyPlot.PlotModel grafico;
        public PlotModel Grafico
        {
            get
            {
                return grafico;
            }
            set
            {
                grafico = value;
            }
        }
    }
}
