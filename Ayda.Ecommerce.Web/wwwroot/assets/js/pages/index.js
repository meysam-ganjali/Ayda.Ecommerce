'use strict';
$(function () {


	$('#new-orders').slimscroll({
		height: '500px',
		size: '5px'
	});
	

	apexBarChart();
	chartjsLineChart();

	desktopCalendar();
	initCardChart();
	initSparkline();
	initLineChart();
	initSalesChart();
	chartdata1();
	chartdata2();
	chartdata3();
});


function apexBarChart() {
	var options = {
        chart: {
            height: 350,
            type: 'bar',
        },
        plotOptions: {
            bar: {
                horizontal: false,
                endingShape: 'rounded',
                columnWidth: '55%',
            },
        },
        dataLabels: {
            enabled: false
        },
        stroke: {
            show: true,
            width: 2,
            colors: ['transparent']
        },
        series: [{
            name: 'سود خالص',
            data: [44, 55, 57, 56, 61, 58, 63, 60, 66]
        }, {
            name: 'درآمد',
            data: [76, 85, 101, 98, 87, 105, 91, 114, 94]
        }, {
            name: 'جریان ازاد نقدینگی',
            data: [35, 41, 36, 26, 45, 48, 52, 53, 41]
        }],
        xaxis: {
            categories: ['فور', 'مار', 'آور', 'مه', 'ژوئن', 'ژول', 'آگو', 'سپت', 'اوک'],
            labels: {
                style: {
                    colors: '#9aa0ac',
                }
            }
        },
        yaxis: {
            title: {
                text: '$ (thousands)'
            },
            labels: {
                style: {
                    color: '#9aa0ac',
                }
            }
        },
        fill: {
            opacity: 1

        },
        tooltip: {
            y: {
                formatter: function (val) {
                    return "$ " + val + " thousands"
                }
            }
        }
    }

    var chart = new ApexCharts(
        document.querySelector("#chart1"),
        options
    );

    chart.render();



}


function chartjsLineChart() {
	try {
	//Sales chart
	var ctx = document.getElementById("line-chart");
	if (ctx) {
		ctx.height = 240;
		var myChart = new Chart(ctx, {
			type: 'line',
			data: {
				labels: ["2010", "2011", "2012", "2013", "2014", "2015", "2016"],
				type: 'line',
				defaultFontFamily: 'iran',
				datasets: [{
					label: "غذاها",
					data: [0, 30, 10, 120, 50, 63, 10],
					backgroundColor: 'transparent',
					borderColor: '#54B253',
					borderWidth: 4,
					pointStyle: 'circle',
					pointRadius: 5,
					pointBorderColor: 'transparent',
					pointBackgroundColor: '#54B253',
				}, {
					label: "الکترونیک",
					data: [0, 50, 40, 80, 40, 79, 120],
					backgroundColor: 'transparent',
					borderColor: '#f96332',
					borderWidth: 4,
					pointStyle: 'circle',
					pointRadius: 5,
					pointBorderColor: 'transparent',
					pointBackgroundColor: '#f96332',
				}]
			},
			options: {
				responsive: true,
				tooltips: {
					mode: 'index',
					titleFontSize: 12,
					titleFontColor: '#000',
					bodyFontColor: '#000',
					backgroundColor: '#fff',
					titleFontFamily: 'iran',
					bodyFontFamily: 'iran',
					cornerRadius: 3,
					intersect: false,
				},
				legend: {
					display: false,
					labels: {
						usePointStyle: true,
						fontFamily: 'iran',
					},
				},
				scales: {
					xAxes: [{
						display: true,
						gridLines: {
							display: false,
							drawBorder: false
						},
						scaleLabel: {
							display: false,
							labelString: 'ماه'
						},
						ticks: {
							fontFamily: "iran",
							fontColor: "#9aa0ac", // Font Color
						}
						
					}],
					yAxes: [{
						display: true,
						gridLines: {
							display: false,
							drawBorder: false
						},
						scaleLabel: {
							display: true,
							labelString: 'Value',
							fontFamily: "iran"

						},
						ticks: {
							fontFamily: "iran",
							fontColor: "#9aa0ac", // Font Color
						}
					}]
				},
				title: {
					display: false,
					text: 'افسانه عادی'
				}
			}
		});
	}


} catch (error) {
	console.log(error);
}
	
}


function initCardChart() {


	//Chart Bar
	$('.chart.chart-bar').sparkline([6, 4, 8, 6, 8, 10, 5, 6, 7, 9, 5, 6, 4, 8, 6, 8, 10, 5, 6, 7, 9, 5], {
		type: 'bar',
		barColor: '#FF9800',
		negBarColor: '#fff',
		barWidth: '4px',
		height: '45px'
	});


	//Chart Pie
	$('.chart.chart-pie').sparkline([30, 35, 25, 8], {
		type: 'pie',
		height: '45px',
		sliceColors: ['#65BAF2', '#F39517', '#F44586', '#6ADF42']
	});


	//Chart Line
	$('.chart.chart-line').sparkline([9, 4, 6, 5, 6, 4, 7, 3], {
		type: 'line',
		width: '60px',
		height: '45px',
		lineColor: '#65BAF2',
		lineWidth: 2,
		fillColor: 'rgba(0,0,0,0)',
		spotColor: '#F39517',
		maxSpotColor: '#F39517',
		minSpotColor: '#F39517',
		spotRadius: 3,
		highlightSpotColor: '#F44586'
	});

	// live chart
	var mrefreshinterval = 500; // update display every 500ms
	var lastmousex = -1;
	var lastmousey = -1;
	var lastmousetime;
	var mousetravel = 0;
	var mpoints = [];
	var mpoints_max = 30;
	$('html').on("mousemove", function (e) {
		var mousex = e.pageX;
		var mousey = e.pageY;
		if (lastmousex > -1) {
			mousetravel += Math.max(Math.abs(mousex - lastmousex), Math.abs(mousey - lastmousey));
		}
		lastmousex = mousex;
		lastmousey = mousey;
	});
	var mdraw = function () {
		var md = new Date();
		var timenow = md.getTime();
		if (lastmousetime && lastmousetime != timenow) {
			var pps = Math.round(mousetravel / (timenow - lastmousetime) * 1000);
			mpoints.push(pps);
			if (mpoints.length > mpoints_max)
				mpoints.splice(0, 1);
			mousetravel = 0;
			$('#liveChart').sparkline(mpoints, {
				width: mpoints.length * 2,
				height: '45px',
				tooltipSuffix: ' پیکسل در ثانیه'
			});
		}
		lastmousetime = timenow;
		setTimeout(mdraw, mrefreshinterval);
	};
	// We could use setInterval instead, but I prefer to do it this way
	setTimeout(mdraw, mrefreshinterval);
}
function initSparkline() {
	$(".sparkline").each(function () {
		var $this = $(this);
		$this.sparkline('html', $this.data());
	});
}

function initLineChart() {
	try {

		//line chart
		var ctx = document.getElementById("lineChart");
		if (ctx) {
			ctx.height = 150;
			var myChart = new Chart(ctx, {
				type: 'line',
				data: {
					labels: ["ژانویه", "فوریه", "مارس", "آوریل", "مه", "ژوئن", "ژولای"],
					defaultFontFamily: "iran",
					datasets: [
						{
							label: "مجموعه داده اول من",
							borderColor: "rgba(0,0,0,.09)",
							borderWidth: "1",
							backgroundColor: "rgba(0,0,0,.07)",
							data: [22, 44, 67, 43, 76, 45, 12]
						},
						{
							label: "مجموعه داده دوم من",
							borderColor: "rgba(0, 123, 255, 0.9)",
							borderWidth: "1",
							backgroundColor: "rgba(0, 123, 255, 0.5)",
							pointHighlightStroke: "rgba(26,179,148,1)",
							data: [16, 32, 18, 26, 42, 33, 44]
						}
					]
				},
				options: {
					legend: {
						position: 'top',
						labels: {
							fontFamily: 'iran'
						}

					},
					responsive: true,
					tooltips: {
						mode: 'index',
						intersect: false
					},
					hover: {
						mode: 'nearest',
						intersect: true
					},
					scales: {
						xAxes: [{
							ticks: {
								fontFamily: "iran"

							}
						}],
						yAxes: [{
							ticks: {
								beginAtZero: true,
								fontFamily: "iran"
							}
						}]
					}

				}
			});
		}


	} catch (error) {
		console.log(error);
	}
}

function initSalesChart() {

	try {
		//Sales chart
		var ctx = document.getElementById("sales-chart");
		if (ctx) {
			ctx.height = 150;
			var myChart = new Chart(ctx, {
				type: 'line',
				data: {
					labels: ["2010", "2011", "2012", "2013", "2014", "2015", "2016"],
					type: 'line',
					defaultFontFamily: 'iran',
					datasets: [{
						label: "غذاها",
						data: [0, 30, 10, 120, 50, 63, 10],
						backgroundColor: 'transparent',
						borderColor: '#222222',
						borderWidth: 2,
						pointStyle: 'circle',
						pointRadius: 3,
						pointBorderColor: 'transparent',
						pointBackgroundColor: '#222222',
					}, {
						label: "الکترونیک",
						data: [0, 50, 40, 80, 40, 79, 120],
						backgroundColor: 'transparent',
						borderColor: '#f96332',
						borderWidth: 2,
						pointStyle: 'circle',
						pointRadius: 3,
						pointBorderColor: 'transparent',
						pointBackgroundColor: '#f96332',
					}]
				},
				options: {
					responsive: true,
					tooltips: {
						mode: 'index',
						titleFontSize: 12,
						titleFontColor: '#000',
						bodyFontColor: '#000',
						backgroundColor: '#fff',
						titleFontFamily: 'iran',
						bodyFontFamily: 'iran',
						cornerRadius: 3,
						intersect: false,
					},
					legend: {
						display: false,
						labels: {
							usePointStyle: true,
							fontFamily: 'iran',
						},
					},
					scales: {
						xAxes: [{
							display: true,
							gridLines: {
								display: false,
								drawBorder: false
							},
							scaleLabel: {
								display: false,
								labelString: 'ماه'
							},
							ticks: {
								fontFamily: "iran"
							}
						}],
						yAxes: [{
							display: true,
							gridLines: {
								display: false,
								drawBorder: false
							},
							scaleLabel: {
								display: true,
								labelString: 'Value',
								fontFamily: "iran"

							},
							ticks: {
								fontFamily: "iran"
							}
						}]
					},
					title: {
						display: false,
						text: 'افسانه عادی'
					}
				}
			});
		}


	} catch (error) {
		console.log(error);
	}
}
function desktopCalendar() {
	var startdate;
	var enddate;
	var today = new Date();
	var year = today.getFullYear();
	var month = today.getMonth();
	var day = today.getDate();
	$('#desktopCal').fullCalendar({
		defaultDate: today,
		defaultView: 'month',
		navLinks: true,
		selectable: true,
		selectHelper: true,
		editable: true,
		header: {
			right: 'prev,today,next'
		},
		events: [{
			title: "تعطیلات",
			start: new Date(year, month, day - 10),
			end: new Date(year, month, day - 8),
			backgroundColor: "#00bcd4"
		}, {
			title: "پریا سارما",
			start: new Date(year, month, day - 3, 13, 30),
			end: new Date(year, month, day - 3, 14, 10),
			backgroundColor: "#fe9701"
		}, {
			title: "ملاقات",
			start: new Date(year, month, day - 6, 17, 30),
			end: new Date(year, month, day - 6, 18, 10),
			backgroundColor: "#F3565D"
		}, {
			title: "سارا اسمیت",
			start: new Date(year, month, day, 19, 10),
			end: new Date(year, month, day, 19, 30),
			backgroundColor: "#1bbc9b"
		}, {
			title: "ایری ساتو",
			start: new Date(year, month, day + 1, 19, 10),
			end: new Date(year, month, day + 1, 19, 30),
			backgroundColor: "#DC35A9",
		}, {
			title: "آنجلیکا راموس",
			start: new Date(year, month, day + 3, 21, 10),
			end: new Date(year, month, day + 3, 21, 30),
			backgroundColor: "#fe9701",
		}, {
			title: "پالاک جانی",
			start: new Date(year, month, day + 10, 11, 30),
			end: new Date(year, month, day + 10, 12, 10),
			backgroundColor: "#00bcd4"
		}, {
			title: "پریا سارما",
			start: new Date(year, month, day + 5, 2, 30),
			end: new Date(year, month, day + 7, 3, 10),
			backgroundColor: "#9b59b6"
		},
		{
			title: "جی سونی",
			start: new Date(year, month, day + 17, 2, 30),
			end: new Date(year, month, day + 19, 3, 10),
			backgroundColor: "#1bbc9b"
		}]

	});


}
function chartdata1() {
	//radar chart
	var ctx = document.getElementById("radar-chart");
	if (ctx) {
		ctx.height = 300;
		var myChart = new Chart(ctx, {
			type: 'radar',
			data: {
				labels: [["خوردن", "شام"], ["نوشیدن", "آب"], "خوابیدن", ["طراحی", "گرافیک"], "کدنویسی", "دوچرخه سواری", "دویدن"],
				defaultFontFamily: 'iran',
				datasets: [
					{
						label: "مجموعه داده اول من",
						data: [65, 59, 66, 45, 56, 55, 40],
						borderColor: "rgba(227, 132, 43, 0.6)",
						borderWidth: "1",
						backgroundColor: "rgba(227, 132, 43, 0.4)"
					},
					{
						label: "مجموعه داده دوم من",
						data: [28, 12, 40, 19, 63, 27, 87],
						borderColor: "rgba(77, 155, 75, 0.7",
						borderWidth: "1",
						backgroundColor: "rgba(77, 155, 75, 0.5)"
					}
				]
			},
			options: {
				legend: {
					 display: false

				},
				scale: {
					ticks: {
						beginAtZero: true,
						fontFamily: "iran",
							fontColor: "#9aa0ac", // Font Color
					}
				}
			}
		});
	}
}

function chartdata2() {
//doughut chart
	var ctx = document.getElementById("doughut-chart");
	if (ctx) {
		ctx.height = 300;
		var myChart = new Chart(ctx, {
			type: 'doughnut',
			data: {
				datasets: [{
					data: [45, 25, 30],
					backgroundColor: [
						"rgba(91, 196, 176,1)",
						"rgba(229, 95, 115, 0.8)",
						"rgba(123, 59, 244, 0.8)",
					],
					hoverBackgroundColor: [
						"rgba(0, 123, 255,0.9)",
						"rgba(0, 123, 255,0.7)",
						"rgba(0, 123, 255,0.5)",
					]

				}],
				labels: [
					"نوع 1",
					"نوع 2",
					"نوع 3"
				]
			},
			options: {
				legend: {
					position: 'bottom',
					labels: {
						fontFamily: 'iran'
					}

				},
				responsive: true
			}
		});
	}
	
}
function chartdata3() {
	//pie chart
	var ctx = document.getElementById("pie-chart");
	if (ctx) {
		ctx.height = 300;
		var myChart = new Chart(ctx, {
			type: 'pie',
			data: {
				datasets: [{
					data: [45, 25, 30],
					backgroundColor: [
						"#4A5767",
						"#72BE81",
						"#DE725C"
					],
					hoverBackgroundColor: [
						"rgba(0, 123, 255,0.9)",
						"rgba(0, 123, 255,0.7)",
						"rgba(0, 123, 255,0.5)"
					]

				}],
				labels: [
					"نوع 1",
					"نوع 2",
					"نوع 3"
				]
			},
			options: {
				legend: {
					position: 'bottom',
					labels: {
						fontFamily: 'iran'
					}

				},
				responsive: true
			}
		});
	}
	
}