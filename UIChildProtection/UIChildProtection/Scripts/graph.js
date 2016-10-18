/*
 * Play with this code and it'll update in the panel opposite.
 *
 * Why not try some of the options above?
 */
Morris.Bar({
    element: 'area-example',
    data: [
    
      { y: '2010', a: 60, b: 35, c: 25 },
      { y: '2011', a: 35, b: 25, c: 10 },
      { y: '2012', a: 22, b: 11, c: 11 },
      { y: '2013', a: 50, b: 40, c: 10 },
      { y: '2014', a: 75, b: 65, c: 30 },
      { y: '2015', a: 120, b: 80, c: 40 },
      { y: '2016', a: 766, b: 49, c: 715 }
    ],
    xkey: 'y',
    ykeys: ['a', 'b', 'c'],
    labels: ['Total Cases ', 'Unsolved', 'solved']
});