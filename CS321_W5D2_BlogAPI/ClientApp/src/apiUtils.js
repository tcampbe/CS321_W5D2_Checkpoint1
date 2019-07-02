export function apiCall(route, options = {}) {
    return fetch(route, options)
    .then((res) => {
      return res.json();
    });
}

