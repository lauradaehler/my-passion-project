<template>
	<div class="add-container" v-on:click.prevent="showInfoModal">
		<button class="add-movie">Add Movie</button>
	</div>
	<div id="moviesTable">
		<table class="table table-dark table-striped table-hover">
			<thead class="thead-light">
				<tr>
					<th>Name</th>
					<th>Description</th>
					<th>Release Year</th>
					<th>Academy Award</th>
					<th>Director ID</th>
					<th style="min-width: 120px" scope="col"></th>
				</tr>
			</thead>
			<tbody>
				<tr v-for="movie in movies" :key="movie.ID">
					<td>{{ movie.name }}</td>
					<td>{{ movie.description }}</td>
					<td>{{ movie.releaseYear }}</td>
					<td>{{ movie.academyAward }}</td>
					<td>{{ movie.directorId }}</td>
					<td>
						<span class="clickable m-2" v-on:click.prevent="showInfoModal">
							<font-awesome-icon icon="fa-solid fa-pen-to-square" />
						</span>
						<span class="clickable m-2" v-on:click.prevent="deleteMovie(movie)">
							<font-awesome-icon icon="fa-solid fa-trash" />
						</span>
					</td>
				</tr>
			</tbody>
		</table>

	</div>

	

	<modal v-show="infoModalVisible">
		<div slot="header">
			<button class="modal-button" v-on:click.prevent="infoModalVisible = false">Close</button>
		</div>
	</modal>
	

	<div class="modal-overlay" v-show="this.deleteConfirmed">
        <div class="confirmation-modal">
            <h3>Movie has been deleted.</h3>
		</div>
	</div>

	<div>
		<button v-on:click="deleteConfirmed = true">Modal</button>
	</div>





</template>

<script>
import { api_getAll, api_post, api_put, api_delete } from "../api.js";
import Modal from "./Modal.vue";

export default {
	components: {
		Modal
	},
	
	data() {
		return {
			infoModalVisible: false,
			deleteConfirmed: false,
			movies: [],
			updatedMovie: {
                    id: 0,
                    name: '',
                    description: '',
                    releaseYear: '',
                    academyAward: '',
                    directorId: ''
			}
		}
	},
	async mounted() {
		this.getMovies();
	},

	methods: {
		async getMovies() {
			let response = await api_getAll();

			if(response == null){
				console.log("There was an error loading the list of movies.");
			} else {
				this.movies = response;
			}
		},
		editMovie(movie) {
			this.updatedMovie.id = movie.id;
			this.updatedMovie.name = movie.name;
			this.updatedMovie.description = movie.description;
			this.updatedMovie.releaseYear = movie.releaseYear;
			this.updatedMovie.academyAward = movie.academyAward;
			this.updatedMovie.directorId = movie.directorId;
		},
		deleteMovie(movie) {
			let response = api_delete(movie.id);

			if(response == true){
				this.movies = response;
				// this.getMovies();
				this.deleteConfirmed = true;
			} else {
				console.log("There was an error deleting this movie.");
			}
		},
		showInfoModal() {
			this.infoModalVisible = true;
		},
		closeInfoModal() {
			this.infoModalVisible = false;
		}
		
	},
}
</script>

<style scoped>

.clickable {
  cursor: pointer;
  user-select: none;
}
.add-container {
	display: flex;
	justify-content: flex-end;
	padding-bottom: 10px;
}
.add-movie {
	border-radius: 8px;
	background-color: rgb(255, 78, 160);
	border-width: 0cap;
	color: rgb(255, 251, 253);
	font-family: 'Courier New', Courier, monospace;
}
.modal-overlay {
	position: fixed;
    top: 0;
	bottom: 0;
	left: 0;
	right: 0;
	display: flex;
	justify-content: center;
    background-color: #000000cc;
}
.confirmation-modal {
    text-align: left;
    background-color: rgb(255, 188, 220);
    color: rgb(255, 27, 133);
    height: fit-content;
    width: fit-content;
    margin: auto;
    padding: 15px;
	padding-bottom: 10px;
    border-radius: 15px;
}

</style>
