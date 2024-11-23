// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Configuración inicial para "Categorías más visitadas"

// Configuración inicial para "Categorías más visitadas"
const categoriasCtx = document.getElementById('categoriasChart').getContext('2d');
const categoriasChart = new Chart(categoriasCtx, {
    type: 'bar',
    data: {
        labels: ['Categoría 1', 'Categoría 2', 'Categoría 3'], // Etiquetas iniciales
        datasets: [{
            label: 'Visitas',
            data: [0, 0, 0], // Datos iniciales
            backgroundColor: ['#4caf50', '#2196f3', '#ff5722'], // Colores de las barras
        }]
    },
    options: {
        responsive: true,
        plugins: {
            legend: { display: false },
        },
        scales: {
            x: { title: { display: true, text: 'Categorías' } },
            y: { title: { display: true, text: 'Visitas' }, beginAtZero: true },
        }
    }
});

// Configuración inicial para "Recetas populares"
const recetasCtx = document.getElementById('recetasChart').getContext('2d');
const recetasChart = new Chart(recetasCtx, {
    type: 'bar',
    data: {
        labels: ['Receta 1', 'Receta 2', 'Receta 3'], // Etiquetas iniciales
        datasets: [{
            label: 'Popularidad',
            data: [0, 0, 0], // Datos iniciales
            backgroundColor: ['#ff9800', '#673ab7', '#03a9f4'], // Colores de las barras
        }]
    },
    options: {
        responsive: true,
        plugins: {
            legend: { display: false },
        },
        scales: {
            x: { title: { display: true, text: 'Recetas' } },
            y: { title: { display: true, text: 'Popularidad' }, beginAtZero: true },
        }
    }
});

// Función para actualizar los gráficos con nuevos datos
function actualizarGrafico(chart, etiquetas, datos) {
    chart.data.labels = etiquetas;
    chart.data.datasets[0].data = datos;
    chart.update();
}

// Ejemplo: Actualizar el gráfico de categorías con nuevos datos
actualizarGrafico(categoriasChart, ['Categoría A', 'Categoría B', 'Categoría C'], [12, 19, 7]);

// Ejemplo: Actualizar el gráfico de recetas con nuevos datos
actualizarGrafico(recetasChart, ['Receta X', 'Receta Y', 'Receta Z'], [5, 15, 10])
