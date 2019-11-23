let mlist = null
let flist = null

function getMovies() {
	let prom1 = fetch('http://localhost:3000/movies', {
		method: 'GET'
	})
	let prom2 = prom1.then((response) => {
		if (response.ok) {
			return response.json()
		}
		if (response.status === 304) {
			return response.json()
		}
		if (response.status === 401) {
			throw new Error('Unauthorized')
		}
		if (response.status === 404) {
			throw new Error('Not Found')
		}
	})
	prom2.then((data) => {
		// console.log(data)
		mlist = data
		data.forEach((item) => {
			let d = document.getElementById("moviesList")
			let l = document.createElement("li")
			l.innerHTML =
			`<div class="box">
				<div class="card text-white bg-dark">
					<img src="${item.posterPath}" alt="${item.title}" class="img-fluid">
					<div class="card-body text-centre">
						<h4 class="card-title">${item.title}</h4>
						<div >
							
							<button class="btn btn-danger" onclick="addFavourite('${item.id}')">Add to Favorites</button>
						</div>
					</div>
				</div>
			</div>`
			d.appendChild(l)
		})
	})
		.catch((error) => {
			console.log(error)
		})

	return prom2
}

function getFavourites() {
	let prom1 = fetch('http://localhost:3000/favourites', {
		method: 'GET'
	})
	let prom2 = prom1.then((response) => {
		if (response.ok) {
			return response.json()
		}
		if (response.status === 304) {
			return response.json()
		}
		if (response.status === 401) {
			throw new Error('Unauthorized')
		}
		if (response.status === 404) {
			throw new Error('Not Found')
		}
	})
	prom2.then((data) => {
		// console.log(data)
		flist = data
		data.forEach((item) => {
			let d = document.getElementById("favouritesList")
			let l = document.createElement("li")
			l.innerHTML =
			`<div class="box">
				<div class="card text-white bg-dark ">
					<img src="${item.posterPath}" alt="${item.title}" class="img-fluid">
					<div class="card-body text-left">
						<h4 class="card-title">${item.title}</h4>
					</div>
				</div>
			</div>`
			d.appendChild(l)
		})
	})
		.catch((error) => {
			console.log(error)
		})

	return prom2
}

function addFavourite(id) {
	let flag = false
	let object = null

	flist.forEach((item, index) => {
		if (item.id == id) {
			flag = true
			throw new Error('Movie is already added to favourites')
		}
	})

	mlist.forEach((item, index) => {
		if (item.id == id) {
			object = item
		}
	})

	if (flag === false) {
		let prom1 = fetch('http://localhost:3000/favourites', {
			method: 'POST',
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(object)
		})
		let prom2 = prom1.then((response) => {
			if (response.ok) {
				flist.push(object)
				return flist
			}
			if (response.status === 304) {
				flist.push(object)
				return flist
			}
			if (response.status === 401) {
				throw new Error('Unauthorized')
			}
			if (response.status === 404) {
				throw new Error('Not Found')
			}
			if (response.status === 500) {
				throw new Error('Movie is already added to favourites')
			}
		})
		prom2.then((data) => {
			// console.log(data)
			let d = document.getElementById("favouritesList")
			let l = document.createElement("li")
			l.innerHTML =
			// `<div class="box">
			// 	<div class="card text-white bg-dark">
			// 		<img src="${item.posterPath}" alt="${item.title}" class="img-fluid">
			// 		<div class="card-body text-left">
			// 			<h4 class="card-title">${item.title}</h4>
						
			// 		</div>
			// 	</div>
			// </div>`
			`<div class="box">
				<div class="card">
					<img src="https://image.tmdb.org/t/p/w500${object.posterPath}" alt="${object.title}" class="img-fluid">
					<div class="card-body text-left">
						<h4 class="card-title">${object.title}</h4>
						<div  >
							
						</div>
					</div>
				</div>
			</div>`
			d.appendChild(l)
		})
			.catch((error) => {
				console.log(error)
			})
			// window.location.reload();
		return prom2
	}
}


module.exports = {
	getMovies,
	getFavourites,
	addFavourite,
};

// You will get error - Uncaught ReferenceError: module is not defined
// while running this script on browser which you shall ignore
// as this is required for testing purposes and shall not hinder
// it's normal execution