let repos = [];
function fetchProjects() {
  const url =
    "https://gitlab-nht.stackroute.in/api/v4/projects?private_token=8S5s5mxWsHv4c1Dh5Zpv";
  return fetch(url)
    .then(res => {
      if (res.ok) {
        return res.json();
      } else {
        if (res.status == 401) throw new Error("You are not allowed to access");
        if (res.status == 404) throw new Error("Please check the url");
      }
    })
    .then(data => data)
    .catch(function(error) {
      throw new Error(error);
    });
}
module.exports = fetchProjects;
