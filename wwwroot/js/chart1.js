var ctx = document.getElementById('lineChart').getContext('2d');
var myChart = new Chart(ctx, {
    type: 'line',
    data: {
      labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug'],
      datasets: [{
      label: 'Improve skills in last 8 months',
      data: [5, 40, 85, 100, 150, 180, 90, 75],
      backgroundColor: [
        'rgb(195, 157, 252)'
      ],
      borderColor: [
        'rgb(75, 14, 181)'
      ],
      borderWidth: 1
    }]
  },
    options: {
      responsive: true,
    }
  });