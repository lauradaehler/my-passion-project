<template>
	<div class="add-container" v-on:click.prevent="showAddMovieModal">
		<button class="add-movie">Add Movie</button>
	</div>
	<div id="moviesTable">
		<table id="movies-table" class="table-light table-pink table-striped table-hover">
			<thead class="thead-pink">
				<tr>
					<th class="th">Name</th>
					<th class="th">Description</th>
					<th class="th">Release Year</th>
					<th class="th">Academy Award</th>
					<th class="thd">Director ID</th>
					<th style="min-width: 120px" scope="col"></th>
				</tr>
			</thead>
			<tbody class="tbody">
				<tr class="tr" v-for="movie in movies" :key="movie.ID">
					<td class="td">{{ movie.name }}</td>
					<td class="td">{{ movie.description }}</td>
					<td class="td">{{ movie.releaseYear }}</td>
					<td class="td">{{ movie.academyAward }}</td>
					<td class="tdd">{{ movie.directorId }}</td>
					<td>
						<span class="clickable m-2" v-on:click.prevent="showUpdateMovieModal(movie)">
							<font-awesome-icon icon="fa-solid fa-pen-to-square" />
						</span>
						<span class="clickable m-2" v-on:click.prevent="showDeleteModal(movie)">
							<font-awesome-icon icon="fa-solid fa-trash" />
						</span>
					</td>
				</tr>
			</tbody>
		</table>

	</div>

	

	<add-movie-modal v-show="addMovieModalVisible" @child-event="handleChildEvent">
	</add-movie-modal>

	<update-movie-modal :movie="parentMovie" v-show="updateMovieModalVisible" @child-event="handleChildEvent"></update-movie-modal>

	

	<div class="modal-overlay" v-show="deleteModalVisible">
		<form class="delete-modal">
			
			<h3>Are you sure you want to delete this movie?</h3>
		
			<div class="button-container">
                <button class="cancel" v-on:click="closeDeleteModal">Cancel</button>
                <button class="save" v-on:click="deleteMovie(this.movieToDelete)">Yes</button>
            </div>
		</form>
	</div>

	<div class="modal-overlay" v-show="deleteSuccessfulVisible">
        <form class="delete-successful-modal" v-on:submit="closeDeleteSuccessfulModal">
            <h3>Movie has been deleted.</h3>

			<div class="button-container">
                <button class="submit">Close</button>
            </div>
		</form>
	</div>

</template>

<script>
import { api_getAll, api_post, api_put, api_delete } from "../api.js";
import AddMovieModal from "./AddMovieModal.vue";
import UpdateMovieModal from "./UpdateMovieModal.vue";

export default {
	components: {
		AddMovieModal,
		UpdateMovieModal
	},
	
	data() {
		return {
			addMovieModalVisible: false,
			updateMovieModalVisible: false,
			deleteModalVisible: false,
			deleteSuccessfulVisible: false,
			movies: [],
			movieToAdd: {},
			movieToUpdate: {},
			movieToDelete: {},
			parentMovie: {}
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

		async addMovie() {
			let response = await api_post(this.movieToAdd);

			if(response === true) {
				this.closeAddMovieModal();
				this.getMovies();
			} else {
				console.log(response)
				console.log("There was an error adding this movie.");
			}
		},

		async updateMovie(movieToUpdate) {
			let response = await api_put(this.movieToUpdate);

			if(response != null) {

				this.getMovies();
				console.log("laura");
				console.log(response);

			} else {
				console.log("There was an error updating this movie.");
			}
		},

		async deleteMovie(movieToDelete) {
			let response = await api_delete(movieToDelete.id);

			if(response == true){
				this.showDeleteSuccessfulModal();
			} else {
				console.log("There was an error deleting this movie.");
			}
		},
		
		showAddMovieModal() {
			this.addMovieModalVisible = true;
		},
		closeAddMovieModal() {
			this.addMovieModalVisible = false;
		},
		showUpdateMovieModal(movie) {
			this.parentMovie = movie;
			this.updateMovieModalVisible = true;
		},
		closeUpdateMovieModal() {
			this.updateMovieModalVisible = false;
		},
		showDeleteModal(movie) {
			this.movieToDelete = movie;
			this.deleteModalVisible = true;
		},
		closeDeleteModal() {
			this.deleteModalVisible = false;
		},
		showDeleteSuccessfulModal() {
			this.deleteSuccessfulVisible = true;
		},
		closeDeleteSuccessfulModal() {
			this.deleteSuccessfulVisible = false;
		},
		handleChildEvent(payload) {
			console.log(payload);
			if (payload == 'cancel') {
				this.closeAddMovieModal();
				this.closeUpdateMovieModal();

			} else if (payload.id == 0) {
				console.log('New movie:', payload);
				this.movieToAdd = payload;
				this.addMovie();
				this.closeAddMovieModal();

			} else if (payload.id > 0) {
				console.log('Updating movie:', payload)
				this.movieToUpdate = payload;
				this.updateMovie(this.movieToUpdate);
				this.closeUpdateMovieModal();
			}
			 else if (payload == null) {
				console.log("error, payload is null");

			} else {
				console.log("error");
			}
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
	background-color: rgb(255, 27, 133);
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
.delete-modal, .delete-successful-modal {
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

.thead-pink {
	background-color: rgb(255, 180, 215);
    color: rgb(253, 17, 127);
	top: 10px;
}

.table-light {
	background-color: rgb(253, 17, 127);
	color: white;
	font-size: large;
}

.table-light:hover {
	color: rgb(255, 156, 202);
}

.tr:hover {
	color: white;
}

.th, .td, .thd {
	padding-left: 20px;
}

.thd {
	column-width: 300px;
}

.tdd {
	text-align: center;
}


td:last-child {
	width: 100px;
	padding-left: -10px;
	text-align: center;
}



</style>
