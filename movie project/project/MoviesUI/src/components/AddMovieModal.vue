<template>
    <div class="modal-overlay">
        <form class="add-movie-modal" v-on:submit.prevent="saveMovie" >
            
            <h3>Add a New Movie</h3>
            <br>

            <div>Name of Movie&colon;
                <input class="field" id="movieName" type="text" v-model="addedMovie.name" maxlength="50" style="width: 198px;" required>
            </div>
            <br>
            
            <div>Description&colon;
                <textarea id="movieDescription" v-model="addedMovie.description" style="width: 217px;" rows="3" maxlength="500">
                </textarea>
            </div>
            <br>

            <div>Release Year&colon;
                <input id="movieReleaseYear" type="text" v-model="addedMovie.releaseYear" minlength="4" maxlength="4" style="width: 207px;" required>
            </div>
            <br>

            <div>Academy Award&colon;
                Yes <input id="movieAcademyAward" type="checkbox" v-model="addedMovie.academyAward" :false-value="null">
                No <input id="movieAcademyAward" type="checkbox" v-model="addedMovie.academyAward"  :true-value="false" :false-value="null">
            </div>
            <br>

            <div>Director Id&colon;
                <input id="movieDirectorId" type="number" v-model="addedMovie.directorId" style="width: 217px;" min=1>
            </div>
            <br>

            <div class="button-container">
                <button class="cancel"  v-on:click="cancel" >Cancel</button>
                <button class="none-selected" :disabled="!academyAwardSelected" v-if="!academyAwardSelected">Save</button>
                <button class="save" type="submit" v-if="academyAwardSelected">Save</button>
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                addedMovie: {
                    id: 0,
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
                this.addedMovie.id = 0;

                if (this.addedMovie.description == '') {
                    this.addedMovie.description = '';
                }
                if (!this.addedMovie.directorId) {
                    this.addedMovie.directorId = 0;
                }

                this.$emit('child-event', this.addedMovie);
                this.addedMovie = {};

            },
            cancel() {
                this.$emit('child-event', 'cancel');
                this.addedMovie = {}
            }
        },
        computed: {
            academyAwardSelected() {
                if (this.addedMovie.academyAward === true || this.addedMovie.academyAward === false) {
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

.add-movie-modal {
    background-color: rgb(255, 180, 215);
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

.cancel, .save, .submit {
    border-radius: 8px;
	background-color: rgb(255, 27, 133);
	border-width: 0cap;
	color: white;
    margin-left: 5px;
}

.none-selected {
    border-radius: 8px;
    background-color: rgb(250, 167, 206);
	border-width: 0cap;
	color: white;
    margin-left: 5px;
}

</style>