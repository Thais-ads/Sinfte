
function Grafico(valorFiltro, valormarca) {

  //debugger;
  var enpoint;


  if (valorFiltro === "hoje") {
    endpoint = '/Hoje';

  } else if (valorFiltro === "estaSemana") {
    endpoint = '/EssaSemana';

  } else if (valorFiltro === "semanaPassada") {
    endpoint = '/log-semanaPassada';

  } else if (valorFiltro === "estemes") {
    endpoint = '/log-mes';

  } else if (valorFiltro === "mesPassado") {
    endpoint = '/log-mesPassado';

  } else {
    endpoint = '/Hoje';
  }

  console.log('http://localhost:5257/api/Log' + endpoint + '?marca=' + valormarca)
  //const id = 123;
  //const url = `https://api.exemplo.com/recurso/${id}`;
  //fetch(url)
  // .then(response => response.json())
  //.then(data => console.log(data));

  //http://192.168.15.5:5000/api/Log/EssaSemana?empresa=aramis


  //const marca = "Aramis";
  //fetch(`http://192.168.15.5:5000/api/Log${endpoint}?empresa=${marca}`)

  fetch('http://localhost:5257/api/Log' + endpoint + '?marca=' + valormarca)

    .then(response => response.json())
    .then(data => {
      const label = data.map(item => item.marcas)
      const offline = data.map(item => parseInt(item.qte_off))
      const online = data.map(item => parseInt(item.qte_caixas - item.qte_off))



      // Destrua o gráfico anterior antes de criar um novo
      var myChart = Chart.getChart("myChart");
      console.log(myChart)

      if (myChart != null) {
        myChart.destroy();

      }




      const canvas = document.getElementById('myChart');
      const ctx = canvas.getContext('2d');

      const chart = new Chart(ctx, {
        type: 'bar',
        data: {
          labels: label, label,
          datasets: [{
            label: 'ativos',
            data: online,
            backgroundColor: 'rgba(54, 162, 235, 0.2)',
            borderColor: 'rgba(54, 162, 235, 1)',
            borderWidth: 1
          }, {
            label: 'desligado',
            data: offline,
            backgroundColor: 'red',
            borderColor: 'red',
            borderWidth: 1
          }]
        },
        options: {

        }
      })

    })



};