const $ = (q) => document.querySelector(q);
const URL = "http://localhost:5028/api/Student";
const stdCon = $("#students");

const loadUsers = async () => {
  const response = await fetch(URL, { method: "GET" });
  const users = await response.json();
  for (let user of users) stdCon.innerHTML += (user?.name ?? "None") + "<br>";
  console.log(users);
};
const searchUser = async () => {
  const id = $("#student-search-id-input").value;
  const response = await fetch(`${URL}/${id}`, { method: "GET" });
  if (response.ok) {
    const user = await response.json();
    $("#student-by-id > section").innerHTML = (user?.name ?? "None") + "<br>";
    console.log(user);
  } else {
    console.log(response.statusText);
    $(
      "#student-by-id > section"
    ).innerHTML = `${response.status} - ${response.statusText}!`;
  }
};

const addUser = async () => {
  const name = $("#username-input").value;
  const body = {
    name,
  };
  const response = await fetch(`${URL}`, {
    method: "POST",
    body: JSON.stringify(body),
    headers: {
      "Content-Type": "application/json",
    },
  });
};

$("#all-students > button").addEventListener("click", (e) => {
  loadUsers();
});

$("#student-by-id > button").addEventListener("click", (e) => {
  searchUser();
});
$("#add-user > button").addEventListener("click", (e) => {
  addUser();
});
