<template>
    <div class="modal-overlay">
        <form class="add-movie-modal" v-on:submit.prevent="saveMovie">
            
            <h3>Add a New Movie</h3>
            <br>

            <div>Name of Movie&colon;
                <input class="field" id="movieName" type="text" v-model="addedMovie.name" maxlength="50" required>
            </div>
            <br>
            
            <div>Description&colon;
                <textarea id="movieDescription" v-model="addedMovie.description" rows="3">
                </textarea>
            </div>
            <br>

            <div>Release Year&colon;
                <input-date id="movieReleaseYear" type="text" v-model="addedMovie.releaseYear" required></input-date>
            </div>
            <br>

            <div>Academy Award&colon;
                Yes <input id="movieAcademyAward" type="checkbox" v-model="addedMovie.academyAward">
                No <input id="movieAcademyAward" type="checkbox" v-model="addedMovie.academyAward" required>

            </div>
            <br>

            <div>Director Id&colon;
                <input id="movieDirectorId" type="text" v-model="addedMovie.directorId">
            </div>
            <br>

            <div class="button-container">
                <button class="cancel"  v-on:click="cancel">Cancel</button>
                <button class="save" type="submit">Save</button>
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
                this.$emit('child-event', this.addedMovie);
                this.addedMovie = {}
            },
            cancel() {
                this.$emit('child-event', 'cancel');
                this.addedMovie = {}
            },

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

.cancel, .save, .submit {
    border-radius: 8px;
	background-color: rgb(255, 27, 133);
	border-width: 0cap;
	color: rgb(255, 251, 253);
    margin-left: 5px;
}


</style>