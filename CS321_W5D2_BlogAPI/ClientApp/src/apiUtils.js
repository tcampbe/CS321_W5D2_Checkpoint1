export function apiCall(route) {
    return fetch(route)
    .then((res) => {
      return res.json();
    });
}
