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
						<span class="clickable m-2" v-on:click="editMovie(movie)">
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

	<div class="modal">
        <div class="modal-content">
            <b-modal>
                <b-form-group>Name
                    <b-form-input id="movieName" type="text" v-model="editMovie.name">
                    </b-form-input>
                </b-form-group>

                <b-form-group>Description
                    <b-form-textarea id="movieDescription" v-model="editMovie.description" rows="3">
                    </b-form-textarea>
                </b-form-group>

                <b-form-group>Release Year
                    <b-form-input id="movieReleaseYear" type="text" v-model="editMovie.releaseYear">
                    </b-form-input>
                </b-form-group>

                <b-form-group>Academy Award
                    <b-form-checkbox id="movieAcademyAward" v-model="editMovie.academyAward">
                    </b-form-checkbox>
                </b-form-group>

                <b-form-group>DirectorId
                    <b-form-input id="movieDirectorId" type="text" v-model="editMovie.directorId">
                    </b-form-input>
                </b-form-group>
            </b-modal>
            
            <!-- <button type="button" class="button-close" v-on:click="close">
                x
            </button> -->


        </div>
    </div>
</template>

<script>
import { api_getAll, api_post, api_put, api_delete } from "../api.js";

export default {
	props: [],
	data() {
		return {
			movies: [],
			editMovie: {
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
                this.editMovie.id = movie.id;
                this.editMovie.name = movie.name;
                this.editMovie.description = movie.description;
                this.editMovie.releaseYear = movie.releaseYear;
                this.editMovie.academyAward = movie.academyAward;
                this.editMovie.directorId = movie.directorId;
		},
		showModal() {
                this.$refs['modal'].show();
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
