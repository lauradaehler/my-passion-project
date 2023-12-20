<template>
    <div class="modal-overlay">
        <div class="edit-modal">
            <h3>Edit Movie</h3>
            <br>

            <div>Name
                <input id="movieName" type="text" v-model="updatedMovie.name">
            </div>
            <br>
            
            <div>Description
                <textarea id="movieDescription" v-model="updatedMovie.description" rows="3">
                </textarea>
            </div>
            <br>

            <div>Release Year
                <input id="movieReleaseYear" type="text" v-model="updatedMovie.releaseYear">
            </div>
            <br>

            <div>Academy Award
                <input id="movieAcademyAward" type="checkbox" v-model="updatedMovie.academyAward">
            </div>
            <br>

            <div>Director Id
                <input id="movieDirectorId" type="text" v-model="updatedMovie.directorId">
            </div>
            <br>
            
            <div class="close" v-on:click="modalVisible = false">
                Close
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                modalVisible: false,
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
            close() {
                this.$emit('close');
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
.edit-modal {
    text-align: left;
    background-color: white;
    height: fit-content;;
    width: 500px;
    margin: auto;
    padding: 20px;
    border-radius: 15px;
}
</style>