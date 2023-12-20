<template>
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
						<span class="clickable m-2" v-on:click.prevent="showModal">
							<font-awesome-icon icon="fa-solid fa-pen-to-square" />
						</span>
						<span class="clickable m-2">
							<font-awesome-icon icon="fa-solid fa-trash" />
						</span>
					</td>
				</tr>
			</tbody>
		</table>

	</div>

	<div>
		<button v-on:click="modalVisible = true">Modal</button>
	</div>

		<modal v-show="modalVisible" @close="closeModal"></modal>



</template>

<script>
import { api_getAll, api_post, api_put, api_delete } from "../api.js";
import Modal from "./Modal.vue";

export default {
	components: {
		Modal
	},
	props: [],
	data() {
		return {
			modalVisible: false,
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
		showModal() {
			this.modalVisible = true;
		},
		closeModal() {
			this.modalVisible = false;
		}
		
	},
}
</script>

<style scoped>

.clickable {
  cursor: pointer;
  user-select: none;
}
</style>
