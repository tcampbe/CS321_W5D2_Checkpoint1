export function apiCall(route, options = {}) {
  var token = localStorage.getItem('token');
  options = {
    ...options,
    headers: {
      ...options.headers,
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + token,
    },
  };
  const apiInfo = {
    route: route,
    options: options,
  };
  return fetch(route, options)
    .then((res) => res.json())
    .then((data) => {
      return Promise.resolve({
        data: data,
        ...apiInfo
      });
    });
}
