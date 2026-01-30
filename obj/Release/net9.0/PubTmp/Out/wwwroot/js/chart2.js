var ctx = document.getElementById('doughnut').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'doughnut',
    data: {
      labels: ['Web Development', 'Creative Skills', 'Language & Communication'],
      datasets: [{
      label: 'Providing Courses',
      data: [10, 8, 4],
      backgroundColor: [
        'rgb(195, 157, 252)',
        'rgb(48, 7, 118)',
        'rgb(106, 40, 221)',
      ],
      borderColor: [
        'rgb(195, 157, 252)',
        'rgb(48, 7, 118)',
        'rgb(106, 40, 221)',
      ],
      borderWidth: 1
    }]
  },
    options: {
      responsive: true,
    }
  });