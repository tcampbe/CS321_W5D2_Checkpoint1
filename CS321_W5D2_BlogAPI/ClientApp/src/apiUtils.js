export function apiCall(route, options = {}) {
  var token = localStorage.getItem('token');
  console.log(options);
  options = {
    ...options,
    headers: {
      ...options.headers,
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + token,
    },
  };
  console.log(options);
  return fetch(route, options).then((res) => {
    return res.json();
  });
}
