/* ÍNICIO CLICK ATIVADO BARRA LATERAL*/

var menu = document.querySelectorAll(".menu li")

menu.forEach(li => {
    li.addEventListener("click",()=> {
        resetMenu();
        li.classList.add("active");
    })
})

function resetMenu() {
    menu.forEach(li => {
        li.classList.remove("active")
    })
}
/* FINAL CLICK ATIVADO BARRA LATERAL*/


/*ÍNICIO GRÁFICOS*/

/*var ctx = document.getElementsByClassName("line-chart");

var chartGraph = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ["Jan","Fev","Mar","Abr","Mai","Jun","Jul","Ago","Set","Out","Nov","Dez"],
        datasets: [{
            label: "TAXA DE OFFLINES - 2023",
            data: [5,10,5,14,20,15,6,14,8,12,15,5,10],
            borderWidth: 4,
            borderColor: 'rgb(75, 192, 192)',
            backgroundColor: 'rgba(75, 192, 192, 0.2)',
        }]
    }
});

/*FINAL GRÁFICOS*/

