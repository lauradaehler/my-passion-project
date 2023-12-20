<template>
    <div class="modal-overlay">
        <form class="edit-modal" v-on:submit.prevent="saveMovie">
            <div class="modal-header">
			<slot name="header">Close</slot>
		    </div>
            <h3>Movie Info</h3>
            <br>

            <div>Name
                <input class="field" id="movieName" type="text" v-model="updatedMovie.name" required>
            </div>
            <br>
            
            <div>Description
                <textarea id="movieDescription" v-model="updatedMovie.description" rows="3">
                </textarea>
            </div>
            <br>

            <div>Release Year
                <input id="movieReleaseYear" type="text" v-model="updatedMovie.releaseYear" required>
            </div>
            <br>

            <div>Academy Award
                <input id="movieAcademyAward" type="checkbox" v-model="updatedMovie.academyAward" required>
            </div>
            <br>

            <div>Director Id
                <input id="movieDirectorId" type="text" v-model="updatedMovie.directorId">
            </div>
            <br>

            <div class="modal-footer">
			<slot name="footer">
                
                <button class="modal-button" v-on:click.prevent="infoModalVisible = false">
                    Close
                </button>
            </slot>
		    </div>

            <div class="save-container">
                <button class="cancel"  v-on:click.prevent="infoModalVisible = false">Cancel</button>
                <input class="submit" type="submit" value="Save">
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                infoModalVisible: false,
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
        methods: {
            closeModal() {
            },
            saveMovie() {}  
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

.edit-modal {
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

.save-container {
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