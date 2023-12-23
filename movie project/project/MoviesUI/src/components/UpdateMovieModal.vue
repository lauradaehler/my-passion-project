<template>
    <div class="modal-overlay">
        <form class="update-movie-modal" v-on:submit.prevent="saveMovie">
            
            <h3>Movie Info</h3>
            <br>

            <div>Name of Movie&colon;
                <input class="field" id="movieName" type="text" v-model="updatedMovie.name" maxlength="50" required>
            </div>
            <br>
            
            <div>Description&colon;
                <textarea id="movieDescription" v-model="updatedMovie.description" rows="3" maxlength="500">
                </textarea>
            </div>
            <br>

            <div>Release Year&colon;
                <input id="movieReleaseYear" type="text" v-model="updatedMovie.releaseYear" minlength="4" maxlength="4" required>
            </div>
            <br>

            <div>Academy Award&colon;
                Yes <input id="movieAcademyAward" type="checkbox" v-model="updatedMovie.academyAward" :false-value="null">
                No <input id="movieAcademyAward" type="checkbox" v-model="updatedMovie.academyAward"  :true-value="false" :false-value="null">
            </div>
            <br>

            <div>Director Id&colon;
                <input id="movieDirectorId" type="number" v-model="updatedMovie.directorId" min="1">
            </div>
            <br>

            <div class="button-container">
                <button class="cancel-grey"  v-on:click="cancel" >Cancel</button>
                <button class="none-selected" :disabled="!academyAwardSelected" v-if="!academyAwardSelected">Save</button>
                <button class="save-grey" type="submit" v-if="academyAwardSelected">Save</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        props: {
            movie: {
                type: Object,
                required: true
            }
            },
        data() {
            return {
                updatedMovie: {
                    id: this.movie.ID,
                    name: '',
                    description: '',
                    releaseYear: '',
                    academyAward: '',
                    directorId: ''
                }
            }
        },
        methods: {
            saveMovie() {
                this.updatedMovie.id = this.movie.id;

                
                if (this.updatedMovie.description == '') {
                    this.updatedMovie.description = '';
                }
                if (!this.updatedMovie.directorId) {
                    this.updatedMovie.directorId = 0;
                }

                this.$emit('child-event', this.updatedMovie);
                this.updatedMovie = {}
            },
            cancel() {
                this.$emit('child-event', 'cancel');
                this.updatedMovie = {}
            }
        },
        computed: {
            academyAwardSelected() {
                if (this.updatedMovie.academyAward === true || this.updatedMovie.academyAward === false) {
                    return true;
                } else {
                    return false;
                }
            }
        }
    };
</script>

<style>
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

.update-movie-modal {
    background-color: white;
    height: fit-content;
    width: fit-content;
    margin: auto;
    padding: 20px;
    border-radius: 15px;
    font-weight: 550;
}

.update-movie-modal-pink {
    background-color: rgb(255, 188, 220);
    color: rgb(255, 27, 133);
    height: fit-content;
    width: fit-content;
    margin: auto;
    padding: 20px;
    border-radius: 15px;
    font-weight: 550;
}

h3 {
    text-align: center;
}

.button-container {
    display: flex;
    justify-content: flex-end;
}

.cancel-grey, .save-grey, .submit-grey {
    border-radius: 8px;
	background-color: rgb(71, 71, 71);
	border-width: 0cap;
    color: white;
    margin-left: 5px;
}

.none-selected {
    border-radius: 8px;
    background-color: rgb(203, 203, 203);
	border-width: 0cap;
	color: white;
    margin-left: 5px;
}

.cancel-pink, .save-pink, .submit-pink {
    border-radius: 8px;
	background-color: rgb(255, 27, 133);
	border-width: 0cap;
	color: white;
    margin-left: 5px;
}


</style>