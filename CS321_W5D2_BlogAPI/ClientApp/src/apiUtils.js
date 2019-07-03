export function apiCall(route, options = {}) {
  var token = localStorage.getItem('token');
  options = {
    method: 'GET',
    ...options,
    headers: {
      ...options.headers,
      'Content-Type': 'application/json'
    },
  };
  if (token) {
    options.headers.Authorization = 'Bearer ' + token;
  }
  const apiInfo = {
    route: route,
    options: options,
  };
  return fetch(route, options)
    .then(res => {
      apiInfo.status = res.status;
      apiInfo.statusText = res.statusText;
      if (!res.ok) {
        throw Error(res.statusText);
      }
      return res;
    })
    .then((res) => res.json())
    .then((data) => {
      apiInfo.data = data;
      return apiInfo;
    })
    .catch(ex => {
      return {
        ...apiInfo,
        error: ex
      };
    });
}
