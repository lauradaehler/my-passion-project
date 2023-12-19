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
						<span class="clickable m-2">
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
</template>

<script>
import { api_getAll, api_post, api_put, api_delete } from "../api.js";

export default {
	props: [],
	data() {
		return {
			movies: []
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
	},
}
</script>

<style scoped>
.clickable {
  cursor: pointer;
  user-select: none;
}
</style>
